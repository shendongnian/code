        static void Main(string[] args) {
            Patient pat1 = new Patient(1, 120);
            Patient pat2 = new Patient(3, 150); // this one can have a 150 bpm hartbeat :)
            Doctor fancyDoctor = new Doctor();
            fancyDoctor.AddPatient(pat1);
            fancyDoctor.AddPatient(pat2);
            Console.ReadKey(true);
        }
        public class Doctor {
            List<Patient> _patients;
            public event EventHandler Working;
            public Doctor() {
                _patients = new List<Patient>();
            }
            public void AddPatient(Patient p) {
                _patients.Add(p);
                p.AbnormalPulses += new EventHandler<AbnormalPulseEventArgs>(p_AbnormalPulses);
            }
            void p_AbnormalPulses(object sender, AbnormalPulseEventArgs e) {
                OnWorking();
                Console.WriteLine("Doctor: Oops, a patient has some strange pulse, giving some valium...");
            }
            protected virtual void OnWorking() {
                if (Working != null) {
                    Working(this, EventArgs.Empty);
                }
            }
            public void RemovePatient(Patient p) {
                _patients.Remove(p);
                p.AbnormalPulses -= new EventHandler<AbnormalPulseEventArgs>(p_AbnormalPulses);
            }
        }
        public class Patient {
            public event EventHandler<AbnormalPulseEventArgs> AbnormalPulses;
            static Random rnd = new Random();
            System.Threading.Timer _puseTmr;
            int _hartBeat;
            public int HartBeat {
                get { return _hartBeat; }
                set {
                    _hartBeat = value;
                    if (_hartBeat > MaxHartBeat) {
                        OnAbnormalPulses(_hartBeat);
                    }
                }
            }
            protected virtual void OnAbnormalPulses(int _hartBeat) {
                Console.WriteLine(string.Format("Abnormal pulsecount ({0}) for patient {1}", _hartBeat, PatientID));
                if (AbnormalPulses != null) {
                    AbnormalPulses(this, new AbnormalPulseEventArgs(_hartBeat));
                }
            }
            public Patient(int patientId, int maxHartBeat) {
                PatientID = patientId;
                MaxHartBeat = maxHartBeat;
                _puseTmr = new System.Threading.Timer(_puseTmr_Tick);
                
                _puseTmr.Change(0, 1000);
            }
            void _puseTmr_Tick(object state) {
                HartBeat = rnd.Next(30, 230);
            }
            public int PatientID {
                get;
                set;
            }
            public int MaxHartBeat {
                get;
                set;
            }
        }
        public class AbnormalPulseEventArgs : EventArgs {
            public int Pulses { get; private set; }
            public AbnormalPulseEventArgs(int pulses) {
                Pulses = pulses;
            }
        }
