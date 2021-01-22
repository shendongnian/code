    if(item.isValueType) {
        newCol.Add(item)
    } elseif(item.isRefType && item.SupportsICloneable) {
        newCol.Add(item.clone())
    } else {
         doReflectionCopy()
    }
