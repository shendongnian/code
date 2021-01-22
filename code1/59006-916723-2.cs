        class paramstest {
            private void _passALot(params Object[] values) {
                System.Console.WriteLine(" [foreach]");
               foreach (object o in values) {
                    System.Console.Write(o.ToString() + ", ");
                }
                System.Console.WriteLine(System.Environment.NewLine + " [for]");
                for (int i = 0; i < values.Length; i += 2) {
                    int? testval = values[i] as Int32?;
                    bool? testbool = values[i + 1] as Boolean?;
                    System.Console.WriteLine(String.Format("Int: {0}, Bool: {1}", testval, testbool));
                }
            }
            public void test() {
                _passALot(1, true, 2, false, 3, true, "q", false);
            }
        }
