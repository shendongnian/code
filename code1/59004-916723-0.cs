        class paramstest {
            private void _passALot(params Object[] values) {
                System.Console.WriteLine(" [foreach]");
               foreach (object o in values) {
                    System.Console.Write(o.ToString() + ", ");
                }
                System.Console.WriteLine(System.Environment.NewLine + " [for]");
                for (int i = 0; i < values.Length; i += 2) {
                    int? testval = (values[i] is Int32) ? (int?)values[i] : null;
                    bool? testbool = (values[i + 1] is Boolean) ? (bool?)values[i+1] : null;
                    System.Console.WriteLine(String.Format("Int: {0}, Bool: {1}", testval, testbool));
                }
            }
            public void test() {
                _passALot(1, true, 2, false, 3, true, "q", false);
            }
        }
