        ...
        class Repeater : IControl
        {
            List<IControl> m_Value = new List<IControl>();
            public IList<IControl> Value
            {
                get { return this.m_Value; }
                set { this.m_Value = (IList<IControl>)value; }
            }
            object IControl.Value
            {
                get
                {
                    return this.m_Value;
                }
                set
                {
                    this.m_Value = new List<IControl>();
                    this.m_Value.Add(new Label());
                    this.m_Value.AddRange((List<IControl>)value);
                }
            }
        }
        ...
        Repeater b = new Repeater();
        IControl i = b;
        List<IControl> list = new List<IControl>();
        list.Add(new Repeater());
        i.Value = list;
