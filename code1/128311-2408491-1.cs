        public void MakeDecisionOnState(State state)
        {
            if (state.IsVacation)
                DoSomething();
            if (state.IsWorking)
                DoSomethingElse();
        }
