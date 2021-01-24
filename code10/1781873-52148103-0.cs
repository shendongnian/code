     var list3 = new RrmModulePermission
     {
          View = list1.View || list2.View,
          Add = list1.Add || list2.Add,
          Edit = list1.Edit || list2.Edit
          Delete = list1.Delete || list2.Delete
      };
      return list3;
