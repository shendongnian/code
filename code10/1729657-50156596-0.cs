        private void DoUpdate(IChangeSet<TObject, TKey> changes)
        {
            foreach (var change in changes)
            {
                switch (change.Reason)
                {
                    case ChangeReason.Add:
                        _target.Insert(change.CurrentIndex, change.Current);
                        break;
                    case ChangeReason.Remove:
                        _target.RemoveAt(change.CurrentIndex);
                        break;
                    case ChangeReason.Moved:
					// ************************************** change from original ************************************************
                    //_target.Move(change.PreviousIndex, change.CurrentIndex);
                    //break;
                    // ************************************** ******************** ************************************************
                    case ChangeReason.Update:
                    {
                        _target.RemoveAt(change.PreviousIndex);
                        _target.Insert(change.CurrentIndex, change.Current);
                    }
                    break;
                }
            }
        }
