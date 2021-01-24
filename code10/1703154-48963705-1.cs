    MyTreeView.ItemsSource = new DataContainer
    {
        Entities = new List<DataEntity>
        {
            new DataEntity
            {
                m_dwID = 1,
                m_pNEXT = new List<DataEntity>
                {
                    new DataEntity
                    {
                        m_dwID = 11
                    },
                    new DataEntity
                    {
                        m_dwID = 12
                    }
                }
            },
    
            new DataEntity
            {
                m_dwID = 2,
                m_pNEXT = new List<DataEntity>
                {
                    new DataEntity
                    {
                        m_dwID = 21,
                        m_pNEXT = new List<DataEntity>
                        {
                            new DataEntity
                            {
                                m_dwID = 211
                            }
                        }
                    }
                }
            }
        }
    }.Entities;
