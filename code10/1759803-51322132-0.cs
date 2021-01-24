    public override IToken Emit()
    {
        IToken t = base.Emit();
        if (t.Type == MyLexer.DATA)
            return base.EmitEOF();
        return t;
    }
