    public override bool TryGetMember(GetMemberBinder binder, out object result)
    {
        if (!this.Dictionary.ContainsKey(binder.Name))
        {
            result = "";
        }
        else
        {
            result = this.Dictionary[binder.Name];
        }
        if (result is IDictionary<string, object>)
        {
            result = new DynamicJsonObject(result as IDictionary<string, object>);
        }
        else if (result is ArrayList && (result as ArrayList) is IDictionary<string, object>)
        {
            result = new List<DynamicJsonObject>((result as ArrayList).ToArray().Select(x => new DynamicJsonObject(x as IDictionary<string, object>)));
        }
        else if (result is ArrayList)
        {
            result = new List<object>((result as ArrayList).ToArray());
        }
        return true; // this.Dictionary.ContainsKey(binder.Name);
    }
