    public void RemoveDecorator(DECORATOR_CODES decCode)
    {
                if (this.Code == decCode)
                {
                    bDecoratorRemoved = true;
                }
                else
                    this.ParentBevarage.RemoveDecorator(decCode);
            }
     public float Cost()
            {
                if (!bDecoratorRemoved)
                    return this.ParentBevarage.Cost() + this.Price;
                else
                    return this.ParentBevarage.Cost();
            }
