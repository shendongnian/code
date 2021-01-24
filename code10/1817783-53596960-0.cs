    private string m_CurrentValue;
    public string CurrentValue
    {
        get { return this.m_CurrentValue; }
        set
        {
            if (m_CurrentValue != value)
            {
                string previousValue = m_CurrentValue;
                //set the field
                this.m_CurrentValue = value;
                if (IsValid(value))
                {
                    SetData(this.m_CurrentValue);
                    this.SendPropertyChangedEvent(nameof(this.CurrentValue));
                }
                else
                {
                    Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        m_CurrentValue = previousValue;
                        this.OnPropertyChanged(nameof(this.CurrentValue));
                    }), DispatcherPriority.ApplicationIdle);
                }
            }
        }
    }
