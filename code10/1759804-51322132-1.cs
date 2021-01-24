    public override IToken Emit()
    {
        string tokenText = base.Text;
        if (this.metaDataOnly && tokenText == "DATA")
            return base.EmitEOF();
        return base.Emit();
    }
