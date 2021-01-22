    class TemplateBase
    {
        public virtual object MyFunc()
        {
            throw new NotImplementedException();
        }
    }
    class TemplateA : TemplateBase
    {
        public override object MyFunc()
        {
            return new ObjTypeA(this);
        }
    }
    class TemplateB : TemplateBase
    {
        public override object MyFunc()
        {
            return new ObjTypeB(this);
        }
    }
