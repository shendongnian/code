    public IEnumerable<IJMonikeElements> GetElements() {
        // Do some magic here to determine which elements are selected
        return (from e in this.allElements where e.IsSelected select e).AsEnumerable();
    
    //  This could also be a complicated loop
    //  while (someCondition()) {
    //      bool isSelected = false;
    //      var item = this.allItems[i++];
    
            // Complicated logic determine if item is selected
    //      if (isSelected) {
    //          yield return item;
    //      }
        }
    }
    public IEnumerable<BusinessObject> GetSelectedObjects() {
        return m_oIJSelectSet.GetElements().Cast<BusinessObject>();
    }
