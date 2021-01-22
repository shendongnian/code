    protected override object SaveControlState()
    {
        object obj = base.SaveControlState();
        if (!string.IsNullOrEmpty(hd_IsDirty.Value))
        {
            if (obj != null)
            {
                return new Pair(obj, hd_IsDirty.Value);
            }
            else
            {
                return hd_IsDirty.Value;
            }
        }
        else
        {
            return obj;
        }
    }
    protected override void LoadControlState(object state)
    {
        if (state != null)
        {
            Pair p = state as Pair;
            if (p != null)
            {
                base.LoadControlState(p.First);
                hd_IsDirty.Value = (string)p.Second;
            }
            else
            {
                if (state is string)
                {
                    hd_IsDirty.Value = (string)state;
                }
                else
                {
                    base.LoadControlState(state);
                }
            }
        }
    }
