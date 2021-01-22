    public new event EventHandler MouseMove {
        add {
            m_Label.MouseMove += value;
            base.MouseMove +=  value;
        }
        remove {
            m_Label.MouseMove -= value;
            base.MouseMove -= value;
        }
    }
