    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    
    namespace Writers
    {
        public class ActionTextWriter : TextWriter
        {
            protected readonly List<Action<string>> Actions = new List<Action<string>>();
    
            public ActionTextWriter(Action<string> action)
            {
                Actions.Add(action);
            }
    
            public ActionTextWriter(IEnumerable<Action<string>> actions)
            {
                Actions.AddRange(actions);
            }
    
            public ActionTextWriter(params Action<string>[] actions)
            {
                Actions.AddRange(actions);
            }
    
            public override Encoding Encoding
            {
                get { return Encoding.Default; }
            }
    
            public override void Write(char[] buffer, int index, int count)
            {
                Write(new string(buffer, index, count));
            }
    
            public override void Write(char value)
            {
                Write(value.ToString());
            }
    
            public override void Write(string value)
            {
                if (value == null)
                {
                    return;
                }
    
                foreach (var action in Actions)
                {
                    action.Invoke(value);
                }
            }
        }
    }
