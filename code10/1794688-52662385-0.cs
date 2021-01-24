         public override string ID
        {
            get
            {
                return base.ID;
            }
  
            set
            {
                base.ID = value;
                if(mTextBox != null)
                    mTextBox.ID = "txt" + base.ID;
            }
        }
