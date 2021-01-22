    using System;
    using System.Timers;
    using System.Windows.Input;
    using Timer = System.Timers.Timer;
    
    namespace Example
    {
        public partial class OnKeyUpInputExample
        {
            // Timer set to elapse after 750ms
            private Timer _timer = new Timer(750) { Enabled = false };
    
            // Constructor
            public OnKeyUpInputExample()
            {
                //What to do when _timer elapses
                _timer.Elapsed += TextInput_OnKeyUpDone;
            }
    
            // Event handler
            private void TextInput_OnKeyUp(object sender, KeyEventArgs e)
            {
                // You could also put the .Stop() in an OnKeyDown event handler if you need to account for keys being held down
                _timer.Stop();
                _timer.Start();
            }
    
            // Function to complement timer elapse
            private void TextInput_OnKeyUpDone(object sender, ElapsedEventArgs e)
            {
                // If we don't stop the timer, it will keep elapsing on repeat.
                _timer.Stop();
    
                this.Dispatcher.Invoke(() =>
                {
                    //Replace with code you want to run.
                    Console.WriteLine("KeyUp timer elapsed");
                });
            }
        }
    }
