    using System;
    using System.Collections.Generic;
    namespace Juliet
    {
        class PrintStateMachine
        {
            int state;
            int max;
            Action<Action>[] actions;
    
            public PrintStateMachine(int max)
            {
                this.state = 0;
                this.max = max;
                this.actions = new Action<Action>[] { IncrPrint, Stop };
            }
    
            void IncrPrint(Action next)
            {
                Console.WriteLine(++state);
                next();
            }
    
            void Stop(Action next) { }
            
            public void Start()
            {
                Action<Action> action = actions[Math.Sign(state - max) + 1];
                action(Start);
            }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                PrintStateMachine printer = new PrintStateMachine(100);
                printer.Start();
                Console.ReadLine();
            }
        }
    }
