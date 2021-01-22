    <#@ template debug="false" hostspecific="false" language="C#" #>
    <#@ assembly name="System.Core" #>
    <#@ import namespace="System.Linq" #>
    <#@ import namespace="System.Text" #>
    <#@ import namespace="System.Collections.Generic" #>
    <#@ output extension=".cs" #>
    <#
    // List of types to generate:
    var createTypeList = new[] { "XDim", "YDim", "YDelta", "DelayValue", "HValue", "Score", "TplIndexValue" };
    #>
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics.Contracts;
    // ReSharper disable CheckNamespace
    <#
        for(int i = 0; i < createTypeList.Length; i++) 
        {
            var typeName = createTypeList[i];
    #>
        [ImmutableObject(true)]
        public struct <#=typeName#> : IComparable<<#=typeName#>>
        {
            public <#=typeName#>(int value) { Value = value; }
            [Pure] public int Value { get; }
            [Pure] public bool Equals(<#=typeName#> other) => Value == other.Value;
            [Pure]
            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj)) return false;
                if (Equals(this, obj)) return true;
                return obj.GetType() == GetType() && Equals((<#=typeName#>)obj);
            }
            [Pure]
            public override int GetHashCode()
            {
                unchecked
                {
                    return (base.GetHashCode() * 397) ^ Value;
                }
            }
            [Pure] public static bool operator ==(<#=typeName#> left, <#=typeName#> right) => Equals(left, right);
            [Pure] public static bool operator !=(<#=typeName#> left, <#=typeName#> right) => !Equals(left, right);
            [Pure] public int CompareTo(<#=typeName#> other) => Equals(this, other) ? 0 : Value.CompareTo(other.Value);
            [Pure] public static bool operator <(<#=typeName#> left, <#=typeName#> right) => Comparer<<#=typeName#>>.Default.Compare(left, right) < 0;
            [Pure] public static bool operator >(<#=typeName#> left, <#=typeName#> right) => Comparer<<#=typeName#>>.Default.Compare(left, right) > 0;
            [Pure] public static bool operator <=(<#=typeName#> left, <#=typeName#> right) => Comparer<<#=typeName#>>.Default.Compare(left, right) <= 0;
            [Pure] public static bool operator >=(<#=typeName#> left, <#=typeName#> right) => Comparer<<#=typeName#>>.Default.Compare(left, right) >= 0;
            [Pure] public override string ToString() => $"{nameof(Value)}: {Value}";
        }
    <#
        }
    #>
