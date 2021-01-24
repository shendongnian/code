    using System;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using System.Threading;
    using ABElectronics_Win10IOT_Libraries;
    using Windows.UI.Popups;
    
    namespace IoPiPlust_start_led
    {
        public sealed partial class MainPage : Page
        {
            int x = 0;
            int y = 0;
            public IOPi bus1 = new IOPi(0x20);
            public IOPi bus2 = new IOPi(0x21);
            int TIME_INTERVAL_IN_MILLISECONDS = 100;
            Timer _timer1;
    
            public MainPage()
            {
                this.InitializeComponent();
                conect();
                _timer1 = new Timer(Timer1_Tick, null, TIME_INTERVAL_IN_MILLISECONDS, Timeout.Infinite);
            }
    
            public async void conect()
            {
                bus1.Connected += Bus1_Connected;
                bus2.Connected += Bus2_Connected;
                await bus1.Connect();
                await bus2.Connect();
                bus2.SetPortDirection(0, 0x00);
                bus1.SetPortDirection(0, 0xFF);
                bus1.SetPortPullups(0, 0xFF);
                bus1.InvertPort(0, 0xFF);
            }
    
            private void Bus2_Connected(object sender, EventArgs e)
            {
                bus2.SetPortDirection(0, 0x00);
            }
    
            private void Bus1_Connected(object sender, EventArgs e)
            {
                ReadBus1();
                _timer1.Change(TIME_INTERVAL_IN_MILLISECONDS, Timeout.Infinite);
            }
    
            private void Timer1_Tick(Object state)
            {
                if (bus1.IsConnected)
                {
                    ReadBus1();
                    if (bus2.IsConnected)
                    {
                        if (bus1.ReadPin(1))
                        { bus2.WritePin(1, true); }
                        if (bus1.ReadPin(2))
                        { bus2.WritePin(2, true); }
                        if (!bus1.ReadPin(1))
                        { bus2.WritePin(1, false); }
                        if (!bus1.ReadPin(2))
                        { bus2.WritePin(2, false); }
                    }
                    _timer1.Change(TIME_INTERVAL_IN_MILLISECONDS, Timeout.Infinite);
                }
            }
    
            public async void ReadBus1()
            {
                if (bus1.IsConnected)
                {
                    try
                    { Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                        {
                            bus1_pin1_chk.IsChecked = bus1.ReadPin(1);
                            bus1_pin2_chk.IsChecked = bus1.ReadPin(2);
                        }
                        );
                    }
                    catch (Exception e)
                    {
                        throw e;
                    }   
                }
            }
    
            private void red_led_btn_Click(object sender, RoutedEventArgs e)
            {
                
                if(x%2==0)
                { bus2.WritePin(2, true); }
                else
                { bus2.WritePin(2, false); }
                x++;
            }
    
            private void green_led_btn_Click(object sender, RoutedEventArgs e)
            {
                
                if (y % 2 == 0)
                {  bus2.WritePin(1, true); }
                else
                { bus2.WritePin(1, false); }
                y++;
            }
    
            private void Button_Click(object sender, RoutedEventArgs e)
            {
                bus2.WritePin(1, false);
                bus2.WritePin(2, false);
                x = 0;
                y = 0;
            }
        }
    }
