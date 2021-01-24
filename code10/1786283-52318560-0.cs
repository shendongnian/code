        public class P2 : P1
        {
            public override void Run<T>(T c)
            {
                c.c1Prop = 1; //Is recognized since you have where T : C1 clause
                var c2 = c as C2;
                if (c2 != null)
                {
                    c2.c2Prop = 2;
                }
            }
        }
