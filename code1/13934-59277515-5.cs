    public void ForEach(Action<T> action)
    {
      if (action == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.match);
      int version = this._version;
      for (int index = 0; index < this._size && (version == this._version || !BinaryCompatibility.TargetsAtLeast_Desktop_V4_5); ++index)
        action(this._items[index]);
      if (version == this._version || !BinaryCompatibility.TargetsAtLeast_Desktop_V4_5)
        return;
      ThrowHelper.ThrowInvalidOperationException(ExceptionResource.InvalidOperation_EnumFailedVersion);
    }
