    [CompilerGenerated]
    [DebuggerDisplay("\\{ firstProperty = {firstProperty}, secondProperty = {secondProperty}, thirdProperty = {thirdProperty} }", Type = "<Anonymous Type>")]
    internal sealed class <>f__AnonymousType0<<firstProperty>j__TPar, <secondProperty>j__TPar, <thirdProperty>j__TPar>
    {
    	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
    	private readonly <firstProperty>j__TPar <firstProperty>i__Field;
    
    	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
    	private readonly <secondProperty>j__TPar <secondProperty>i__Field;
    
    	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
    	private readonly <thirdProperty>j__TPar <thirdProperty>i__Field;
    
    	public <firstProperty>j__TPar firstProperty
    	{
    		get
    		{
    			return <firstProperty>i__Field;
    		}
    	}
    
    	public <secondProperty>j__TPar secondProperty
    	{
    		get
    		{
    			return <secondProperty>i__Field;
    		}
    	}
    
    	public <thirdProperty>j__TPar thirdProperty
    	{
    		get
    		{
    			return <thirdProperty>i__Field;
    		}
    	}
    
    	[DebuggerHidden]
    	public <>f__AnonymousType0(<firstProperty>j__TPar firstProperty, <secondProperty>j__TPar secondProperty, <thirdProperty>j__TPar thirdProperty)
    	{
    		<firstProperty>i__Field = firstProperty;
    		<secondProperty>i__Field = secondProperty;
    		<thirdProperty>i__Field = thirdProperty;
    	}
    
    	[DebuggerHidden]
    	public override bool Equals(object value)
    	{
    		<>f__AnonymousType0<<firstProperty>j__TPar, <secondProperty>j__TPar, <thirdProperty>j__TPar> anon = value as <>f__AnonymousType0<<firstProperty>j__TPar, <secondProperty>j__TPar, <thirdProperty>j__TPar>;
    		return anon != null && EqualityComparer<<firstProperty>j__TPar>.Default.Equals(<firstProperty>i__Field, anon.<firstProperty>i__Field) && EqualityComparer<<secondProperty>j__TPar>.Default.Equals(<secondProperty>i__Field, anon.<secondProperty>i__Field) && EqualityComparer<<thirdProperty>j__TPar>.Default.Equals(<thirdProperty>i__Field, anon.<thirdProperty>i__Field);
    	}
    
    	[DebuggerHidden]
    	public override int GetHashCode()
    	{
    		return ((1541079692 * -1521134295 + EqualityComparer<<firstProperty>j__TPar>.Default.GetHashCode(<firstProperty>i__Field)) * -1521134295 + EqualityComparer<<secondProperty>j__TPar>.Default.GetHashCode(<secondProperty>i__Field)) * -1521134295 + EqualityComparer<<thirdProperty>j__TPar>.Default.GetHashCode(<thirdProperty>i__Field);
    	}
    
    	[DebuggerHidden]
    	public override string ToString()
    	{
    		object[] obj = new object[3];
    		<firstProperty>j__TPar val = <firstProperty>i__Field;
    		ref <firstProperty>j__TPar reference = ref val;
    		<firstProperty>j__TPar val2 = default(<firstProperty>j__TPar);
    		object obj2;
    		if (val2 == null)
    		{
    			val2 = reference;
    			reference = ref val2;
    			if (val2 == null)
    			{
    				obj2 = null;
    				goto IL_0046;
    			}
    		}
    		obj2 = reference.ToString();
    		goto IL_0046;
    		IL_0081:
    		object obj3;
    		obj[1] = obj3;
    		<thirdProperty>j__TPar val3 = <thirdProperty>i__Field;
    		ref <thirdProperty>j__TPar reference2 = ref val3;
    		<thirdProperty>j__TPar val4 = default(<thirdProperty>j__TPar);
    		object obj4;
    		if (val4 == null)
    		{
    			val4 = reference2;
    			reference2 = ref val4;
    			if (val4 == null)
    			{
    				obj4 = null;
    				goto IL_00c0;
    			}
    		}
    		obj4 = reference2.ToString();
    		goto IL_00c0;
    		IL_00c0:
    		obj[2] = obj4;
    		return string.Format(null, "{{ firstProperty = {0}, secondProperty = {1}, thirdProperty = {2} }}", obj);
    		IL_0046:
    		obj[0] = obj2;
    		<secondProperty>j__TPar val5 = <secondProperty>i__Field;
    		ref <secondProperty>j__TPar reference3 = ref val5;
    		<secondProperty>j__TPar val6 = default(<secondProperty>j__TPar);
    		if (val6 == null)
    		{
    			val6 = reference3;
    			reference3 = ref val6;
    			if (val6 == null)
    			{
    				obj3 = null;
    				goto IL_0081;
    			}
    		}
    		obj3 = reference3.ToString();
    		goto IL_0081;
    	}
    }
