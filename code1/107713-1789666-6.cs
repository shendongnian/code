    private IList<BCSFilter> _BCSFilters;
    // Create out "key" to use for locking
    private object _BCSFiltersLOCK = new Object();
    /// <summary>
    /// Gets or sets the BCS filters.
    /// </summary>
    /// <value>The BCS filters.</value>
    public IList<BCSFilter> BCSFilters
    {
        get
        {
            if (_BCSFilters == null)
            {
                // Lock the object before modifying it, so other
                // simultaneous calls don't step on each other
                lock(_BCSFiltersLOCK)
                {
                    if (_BCSFilters == null)
                    }
                        _BCSFilters = new List<BCSFilter>();
                    }
                }
            }
            return _BCSFilters;
        }
        set
        {
            _BCSFilters = value;
        }
    }
