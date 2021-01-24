    using System;
    using System.Globalization;
    using System.Diagnostics;
    
    // Instructions to compile (With mono)
    // csc Program.cs
    // mono Program.exe
    
    class Program {
        static void Main(string[] args) {
            TimerExample_V1 timer_v1 = new TimerExample_V1();
            TimerExample_V2 timer_v2 = new TimerExample_V2();
    
            Stopwatch profiler;
            int nbBenchLoops = 10000; // 10 000 times
            float t1;
            float t2;
    
            // Profil version 1
            profiler = Stopwatch.StartNew();
            for(int k = 0; k < nbBenchLoops; ++k) {
                timer_v1.UpdateCurrentTimeUI();
            }
            t1 = profiler.ElapsedMilliseconds;
    
    
            // Profil version 2
            profiler = Stopwatch.StartNew();
            for(int k = 0; k < nbBenchLoops; ++k) {
                timer_v2.UpdateCurrentTimeUI();
            }
            t2 = profiler.ElapsedMilliseconds;
    
    
            // Print mesured times
            Console.WriteLine("[SCOPE_PROFILER] [Version 1]: {0} ms", t1);
            Console.WriteLine("[SCOPE_PROFILER] [Version 2]: {0} ms", t2);
        }
    }
    
    //
    // Version 1
    //
    class Timer`enter code here`Example_V1 {
        private string      m_TimeNow = System.Convert.ToString(System.DateTime.Now);
        private string      m_PreTime = System.Convert.ToString(System.DateTime.Now);
        private string[]    m_Times;
        private string      m_Time;
    
        public void UpdateCurrentTimeUI() {
            m_TimeNow = System.Convert.ToString(System.DateTime.Now);
    
            if (m_PreTime != m_TimeNow.Remove(14)) {
                // Note: this case appear only once per minute.
                m_PreTime   = m_TimeNow.Remove(14);
                m_Times     = m_TimeNow.Split(' ');
                m_Time      = m_Times[1].Remove(4);
    
                string newText = m_Time + " " + m_Times[2];
                //m_Text_Time.text = newText; // Update unity display
                // I omit this display unity. (Same cost in both case)
            }
    
        }
    }
    
    
    // 
    // Version 2
    // 
    class TimerExample_V2 {
        private DateTime    _TimeNow = System.DateTime.Now;
        private DateTime    _PreTime = System.DateTime.Now;
        private string      _format = "t";
        private string      _cultureName = "en-US";
    
        public TimerExample_V2() {
            CultureInfo culture = new CultureInfo(_cultureName);
            CultureInfo.CurrentCulture = culture;
        }
    
        public void UpdateCurrentTimeUI() {
            _TimeNow = System.DateTime.Now;
    
            if(_PreTime.Minute != _TimeNow.Minute) {
                // Note: this case appear only once per minute.
                _PreTime = System.DateTime.Now;
                string newText = _TimeNow.ToString(_format);
                //m_Text_Time.text = newText; // Update unity display
                // I omit this display unity. (Same cost in both case)
            }
        }
    }
