        #region IsCheckable
        public bool IsCheckable
        {
            get
            {
                lock(m_IsCheckable_Lock)
                {
                    return m_IsCheckable;
                }
            }
            protected set
            {
                bool fire = false;
                lock(m_IsCheckable_Lock)
                {
                    if (m_IsCheckable != value)
                    {
                        m_IsCheckable = value;
                        fire = true;
                    }
                }
                if(fire)
                {
                    NotifyPropertyChanged(m_IsCheckableArgs);
                }
            }
        }
        private readonly object m_IsCheckable_Lock = new object();
        private bool m_IsCheckable = false;
        static readonly PropertyChangedEventArgs m_IsCheckableArgs =
            NotifyPropertyChangedHelper.CreateArgs<MyViewModel>(o => 
                    o.IsCheckable);
        #endregion
