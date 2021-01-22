    using System;
    using System.Collections;
    using System.IO;
    using System.Reflection;
    
    class KeyboardExtractor {
    
        static Object InvokeNonPublicStaticMethod(Type t, String name,
                Object[] args)
        {
            return t.GetMethod(name, BindingFlags.Static | BindingFlags.NonPublic)
                .Invoke(null, args);
        }
    
        static void InvokeNonPublicInstanceMethod(Object o, String name,
                Object[] args)
        {
            o.GetType().GetMethod(name, BindingFlags.Instance |
                    BindingFlags.NonPublic) .Invoke(o, args);
        }
    
        static Object GetNonPublicProperty(Object o, String propertyName) {
            return o.GetType().GetField(propertyName,
                    BindingFlags.Instance | BindingFlags.NonPublic)
                .GetValue(o);
        }
    
        static void SetNonPublicField(Object o, String propertyName, Object v) {
            o.GetType().GetField(propertyName,
                    BindingFlags.Instance | BindingFlags.NonPublic)
                .SetValue(o, v);
        }
    
        [STAThread] public static void Main() {
            System.Console.WriteLine("Keyboard Extractor...");
    
            KeyboardExtractor ke = new KeyboardExtractor();
            ke.extractAll();
    
            System.Console.WriteLine("Done.");
        }
    
        Assembly msklcAssembly;
        Type utilitiesType;
        Type keyboardType;
        String baseDirectory;
    
        public KeyboardExtractor() {
            msklcAssembly = Assembly.LoadFile("C:\\Program Files\\Microsoft Keyboard Layout Creator 1.4\\MSKLC.exe");
            utilitiesType = msklcAssembly.GetType("Microsoft.Globalization.Tools.KeyboardLayoutCreator.Utilities");
            keyboardType = msklcAssembly.GetType("Microsoft.Globalization.Tools.KeyboardLayoutCreator.Keyboard");
    
            baseDirectory = Directory.GetCurrentDirectory();
        }
    
        public void extractAll() {
    
            DateTime startTime = DateTime.UtcNow;
    
            SortedList keyboards = (SortedList)InvokeNonPublicStaticMethod(
                    utilitiesType, "KeyboardsOnMachine", new Object[] {false});
    
            DateTime loopStartTime = DateTime.UtcNow;
    
            int i = 0;
            foreach (DictionaryEntry e in keyboards) {
                i += 1;
                Object k = e.Value;
    
                String name = (String)GetNonPublicProperty(k, "m_stLayoutName");
                String layoutHexString = ((UInt32)GetNonPublicProperty(k, "m_hkl"))
                    .ToString("X");
    
                TimeSpan elapsed = DateTime.UtcNow - loopStartTime;
                Double ticksRemaining = ((Double)elapsed.Ticks * keyboards.Count)
                            / i - elapsed.Ticks;
                TimeSpan remaining = new TimeSpan((Int64)ticksRemaining);
                String msgTimeRemaining = "";
                if (i > 1) {
                    // Trim milliseconds
                    remaining = new TimeSpan(remaining.Hours, remaining.Minutes,
                            remaining.Seconds);
                    msgTimeRemaining = String.Format(", about {0} remaining",
                            remaining);
                }
                System.Console.WriteLine(
                        "Saving {0} {1}, keyboard {2} of {3}{4}",
                        layoutHexString, name, i, keyboards.Count,
                        msgTimeRemaining);
    
                SaveKeyboard(name, layoutHexString);
    
            }
    
            System.Console.WriteLine("{0} elapsed", DateTime.UtcNow - startTime);
    
        }
    
        private void SaveKeyboard(String name, String layoutHexString) {
            Object k = keyboardType.GetConstructors(
                    BindingFlags.Instance | BindingFlags.NonPublic)[0]
                .Invoke(new Object[] {
                            new String[] {"", layoutHexString},
                        false});
    
            SetNonPublicField(k, "m_fSeenOrHeardAboutPropertiesDialog", true);
            SetNonPublicField(k, "m_stKeyboardTextFileName",
                    String.Format("{0}\\{1} {2}.klc",
                        baseDirectory, layoutHexString, name));
            InvokeNonPublicInstanceMethod(k, "mnuFileSave_Click",
                    new Object[] {new Object(), new EventArgs()});
    
            ((IDisposable)k).Dispose();
        }
    
    }
