    private uicontrol_isValidating(...)
    {
        if(!m_Model.MemberNameIsValid())
        {
            errorProvider.SetError(...);
        }
    }
