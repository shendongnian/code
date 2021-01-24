    using SharpDX.DirectInput;
    using System;
    using System.Diagnostics;
    using System.Threading.Tasks;
    
    namespace ConsoleApp2
    {
        class Program
        {
            static void Main(string[] args)
            {
                var controller = new Controller();
            }
        }
    
        public class Controller
        {
            private Task pollingTask;
            private bool running;
    
            private JoystickState state;
    
            public JoystickState State => state ?? (state = controller.GetCurrentState());
            public Joystick controller;
            public Controller()
            {
                var directInput = new DirectInput();
                var handle = Process.GetCurrentProcess().MainWindowHandle;
                var diDevices = directInput.GetDevices(DeviceClass.GameControl, DeviceEnumerationFlags.AttachedOnly);
                controller = new Joystick(directInput, diDevices[0].InstanceGuid);
                controller.SetCooperativeLevel(handle, CooperativeLevel.Exclusive | CooperativeLevel.Background);
                controller.Acquire();
                running = true;
                PollJoystick();
    
                if (pollingTask != null)
                {
                    pollingTask.Wait();
                }
                Console.WriteLine("fini");
                Console.ReadKey();
            }
            TimeSpan period = TimeSpan.FromMilliseconds(30);
            public int[] Pov => State.PointOfViewControllers;
            public bool stop => State.Buttons[0];
            public void PollJoystick()
            {
                pollingTask = Task.Factory.StartNew(() => {
                    while (running)
                    {
                        state = null;
                        running = !stop;
                        if (Pov[0] != -1)
                            Console.WriteLine(Pov[0]);
                        Task.Delay(period);
                    }
                });
            }
        }
    }
