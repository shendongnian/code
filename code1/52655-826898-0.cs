    switch (this._tokenId)
        {
            case TokenId.ExitToken:
            {
                int exitCode = this.GetExitCode(result);
                throw new ExitException(base.NodeToken, exitCode);
            }
            case TokenId.ReturnToken:
                throw new ReturnException(base.NodeToken, result);
    
            case TokenId.BreakToken:
                label = this.GetLabel(result, context);
                throw new BreakException(base.NodeToken, label);
    
            case TokenId.ContinueToken:
                label = this.GetLabel(result, context);
                throw new ContinueException(base.NodeToken, label);
