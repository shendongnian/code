      /// <summary>
      ///    Returns all children elements of an automation element.
      /// </summary>
      /// <param name="automationElement"></param>
      /// <returns></returns>
      public static List<AutomationElement> AllChildren(AutomationElement automationElement)
      {
         if (automationElement == null) throw new ArgumentNullException(nameof(automationElement));
         AutomationElement firstChild = TreeWalker.RawViewWalker.GetFirstChild(automationElement);
         if (firstChild == null)
            return new List<AutomationElement>();
         List<AutomationElement> children = new List<AutomationElement> { firstChild };
         AutomationElement sibling;
         int childIndex = 0;
         while ((sibling = TreeWalker.RawViewWalker.GetNextSibling(children[childIndex])) != null)
         {
            children.Add(sibling);
            childIndex++;
         }
         return children;
      }
