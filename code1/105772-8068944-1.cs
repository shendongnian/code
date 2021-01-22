     // --------------------------------------------------------------------------------
     /// <summary>This class is used for strongly typed sortable lists of generic
     /// objects (such as data access or business objects).</summary>
     ///
     /// <remarks></remarks>
     // --------------------------------------------------------------------------------
     public class GenericList<T> : IGenericList<T>
               where T : IGenericObject, new()
     {
    
      // --------------------------------------------------------------------------------
      /// <summary>Base constructor.</summary>
      // --------------------------------------------------------------------------------
      public GenericList()
      {
      }
    
      // --------------------------------------------------------------------------------
      /// <summary>This constructor takes in a generic list of the same
      /// type and transforms it to this list.</summary>
      /// 
      /// <param name="inputGenericList">The input list to transform to this list.</param>
      /// <param name="filterElements">Field and property values to exclude from transform.</param>
      // --------------------------------------------------------------------------------
      public GenericList(GenericList<T> inputGenericList, NameObjectCollection filterElements)
      {
       if (inputGenericList != null)
       {
        foreach (T loopItem in inputGenericList)
        {
         T newItem = new T();
         DataTransformHelper.TransformDataFromObject(loopItem, newItem, filterElements);
         Add(newItem);
        }
       }
      }
    
      // --------------------------------------------------------------------------------
      /// <summary>This constructor takes in a generic list of another
      /// type and transforms it to this list.</summary>
      /// 
      /// <param name="inputListElementType">The type of element to be found in the input list.</param>
      /// <param name="inputGenericList">The input list to transform to this list.</param>
      /// <param name="filterElements">Field and property values to exclude from transform.</param>
      // --------------------------------------------------------------------------------
      public GenericList(Type inputListElementType, object inputGenericList, NameObjectCollection filterElements)
      {
       if (inputGenericList != null)
       {
        Type inputListType = typeof(GenericList<>);
        Type combinedType = inputListType.MakeGenericType(inputListElementType);
        IList elements = (IList) Activator.CreateInstance(combinedType, inputGenericList, filterElements);
        foreach (IGenericObject loopItem in elements)
        {
         T newItem = new T();
         DataTransformHelper.TransformDataFromObject(loopItem, newItem, filterElements);
         Add(newItem);
        }
       }
      }
     }
