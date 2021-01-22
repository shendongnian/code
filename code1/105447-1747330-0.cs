    /// <summary>Returns the highest value encountered in an enumeration</summary>
    /// <typeparam name="EnumType">
    ///   Enumeration of which the highest value will be returned
    /// </typeparam>
    /// <returns>The highest value in the enumeration</returns>
    private static EnumType highestValueInEnum<EnumType>() where EnumType : IComparable {
      EnumType[] values = (EnumType[])Enum.GetValues(typeof(EnumType));
      EnumType highestValue = values[0];
      for(int index = 0; index < values.Length; ++index) {
        if(values[index].CompareTo(highestValue) > 0) {
          highestValue = values[index];
        }
      }
      return highestValue;
    }
