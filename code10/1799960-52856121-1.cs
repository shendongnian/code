        private QuestionViewModel currentQuestion;
        public QuestionViewModel CurrentQuestion
        {
            get
            {
                return this.currentQuestion;
            }
            set
            {
                this.currentQuestion = value;
                this.NotifyPropertyChanged();
            }
        }
