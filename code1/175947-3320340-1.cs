    using System;
    using System.Runtime.InteropServices;
    
    class MelodyPlayer
    {
        const double ConcertPitch = 440.0;
    
        class Note
        {
            [DllImport("Kernel32.dll")]
            public static extern bool Beep(UInt32 frequency, UInt32 duration);
    
            public const int C = -888;
            public const int CSharp = -798;
            public const int DFlat = CSharp;
            public const int D = -696;
            public const int DSharp = -594;
            public const int EFlat = DSharp;
            public const int E = -498;
            public const int F = -390;
            public const int FSharp = -300;
            public const int GFlat = FSharp;
            public const int G = -192;
            public const int GSharp = -96;
            public const int AFlat = GSharp;
            public const int A = 0;
            public const int ASharp = 108;
            public const int BFlat = ASharp;
            public const int B = 204;
    
            public int Key { get; set; }
            public int Octave { get; set; }
            public uint Duration { get; set; }
    
            public Note(int key, int octave, uint duration)
            {
                this.Key = key;
                this.Octave = octave;
                this.Duration = duration;
            }
    
            public uint Frequency
            {
                get
                {
                    double factor = Math.Pow(2.0, 1.0 / 1200.0);
                    return ((uint)(MelodyPlayer.ConcertPitch * Math.Pow(factor, this.Key + this.Octave * 1200.0)));
                }
            }
    
            public void Play()
            {
                Beep(this.Frequency, this.Duration);
            }
        }
    
        static void Main(string[] args)
        {
            Note[] melody = new Note[] {
                new Note(Note.C, 0, 100),
                new Note(Note.C, 0, 100),
                new Note(Note.D, 0, 100),
                new Note(Note.E, 0, 100),
                new Note(Note.F, 0, 100),
                new Note(Note.G, 0, 100),
                new Note(Note.A, 0, 100),
                new Note(Note.B, 0, 100),
                new Note(Note.C, 1, 100),
                new Note(Note.D, 1, 100),
                new Note(Note.E, 1, 100),
                new Note(Note.F, 1, 100),
                new Note(Note.G, 1, 100),
                new Note(Note.A, 1, 100),
                new Note(Note.B, 1, 100),
                new Note(Note.C, 2, 100)
            };
            
            foreach (var note in melody)
            {
                note.Play();
            }
        }
    }
