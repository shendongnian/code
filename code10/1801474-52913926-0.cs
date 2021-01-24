        ...
        
                            if (lenghtText + 1 == (this.Text.Length))
                                this.CaretIndex = caret + 1;
                            else
                                this.CaretIndex = caret;
                        }
        
        
                    }
                    catch
                    {
        
                    }
        base.OnTextChanged(e);
    
    }
