    using System;
    using KellermanSoftware.CompareNetObjects;
    
    namespace Compare
    {
    
    	/// <summary>
    	/// This allows us to compare objects based on a particular class (ie so we can compare on base classes)
    	/// </summary>
    	public class BaseClassComparer : KellermanSoftware.CompareNetObjects.TypeComparers.ClassComparer
    	{
    
    
    		private readonly Type _compareType;
    		internal BaseClassComparer(Type compareType, RootComparer rootComparer) : base(rootComparer)
    		{
    
    			_compareType = compareType;
    		}
    
    		public override void CompareType(CompareParms parms)
    		{
    			parms.Object1Type = _compareType;
    			parms.Object2Type = _compareType;
    
    			base.CompareType(parms);
    		}
    
    		public override bool IsTypeMatch(Type type1, Type type2)
    		{
    			if (((_compareType.IsAssignableFrom(type1)) && (_compareType.IsAssignableFrom(type2)))) {
    				return true;
    			} else {
    				return false;
    			}
    		}
    	}
    }
