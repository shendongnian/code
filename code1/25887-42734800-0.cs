            public class CaseSmile : IAction, ICase<int?>
            {
                public int? Key { get { return 1; } }
                public void Sense(ISense sense)
                {
                    sense.Smile();
                }
            }
