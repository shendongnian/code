    class Origin {
      public bool IsAllowed { get; set; }
      public bool IsGloballyAllowed { get; set; }
      public Origin(bool isAllowed, bool isGloballyAllowed) {
        IsAllowed = isAllowed;
        IsGloballyAllowed = isGloballyAllowed;
      }
      public bool? CheckState {
        get {
          if (IsAllowed && IsGloballyAllowed)
            return true;
          if (!IsAllowed && !IsGloballyAllowed)
            return false;
          //if (IsAllowed == true && IsGloballyAllowed == false)
          //  return null;
          return null;
        }
      }
    }
