        interface IControl
        {
            object Value();
        }
        class A : IControl
        {
            string m_value = string.Empty;
            public object Value() { return m_value; }
        };
        class B : IControl
        {
            List<IControl> m_value = new List<IControl>();
            public object Value() { return m_value; }
        };
        ....
        object o = new B().Value();
        if (o is List<IControl>)
            MessageBox.Show("List");
