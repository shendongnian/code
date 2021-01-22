            public class CaseCry : IAction, ICase<int?>
            {
                public int? Key { get { return 2; } }
                public void Do()
                {
                    Sense.Cry cry = new Sense.Cry();
                    cry.Act();
                }
            }
