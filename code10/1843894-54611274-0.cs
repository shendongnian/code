    class MyForms
    {
        private static Menu _menu = null;
        public static Menu menu {
            get {
                if (_menu == null || _menu.IsDisposed)
                {
                    _menu = new Menu();
                    _menu.FormClosed += (sender, e) => { _menu = null; };
                }
                return _menu;
            }
        }
        private static RandomFacts _randomFacts = null;
        public static Menu randomFacts
        {
            get
            {
                if (_randomFacts == null || _randomFacts.IsDisposed)
                {
                    _randomFacts = new RandomFacts();
                    _randomFacts.FormClosed += (sender, e) => { _randomFacts = null; };
                }
                return _menu;
            }
        }
        private static QuizMenu _qm = null;
        public static QuizMenu qm
        {
            get
            {
                if (_qm == null || _qm.IsDisposed)
                {
                    _qm = new QuizMenu();
                    _qm.FormClosed += (sender, e) => { _qm = null; };
                }
                return _qm;
            }
        }
        private static AskHowManyQuestions _ahmq = null;
        public static AskHowManyQuestions ahmq
        {
            get
            {
                if (_ahmq == null || _ahmq.IsDisposed)
                {
                    _ahmq = new AskHowManyQuestions();
                    _ahmq.FormClosed += (sender, e) => { _ahmq = null; };
                }
                return _ahmq;
            }
        }
    }
