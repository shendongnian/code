    class RationalBignum {
        public Bignum Numerator { get; set; }
        public Bignum Denominator { get; set; }
    }
    class BigMeanr {
        public static int Main(string[] argv) {
            var sum = new RationalBignum(0);
            var n = new Bignum(0);
            using (var s = new FileStream(argv[0])) {
                using (var r = new BinaryReader(s)) {
                    while (true) {
                        try {
                            var flt = r.ReadSingle();
                            rat = new RationalBignum(flt);
                            sum += rat;
                        }
                        catch (EndOfStreamException) {
                            break;
                        }
                    }
                }
            }
            Console.WriteLine("The mean is: {0}", sum / n);
        }
    }
