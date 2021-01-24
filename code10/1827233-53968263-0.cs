    /// <summary>
    /// The time to wait before closing idle connections in the pool if the count
    /// of all connections exceeds MinPoolSize.
    /// </summary>
    /// <value>The time (in seconds) to wait. The default value is 300.</value>
    [Category("Pooling")]
    [Description("The time to wait before closing unused connections in the pool if the count of all connections exceeds MinPoolSize.")]
    [DisplayName("Connection Idle Lifetime")]
    [NpgsqlConnectionStringProperty]
    [DefaultValue(300)]
    public int ConnectionIdleLifetime
    {
        get => _connectionIdleLifetime;
        set
        {
            _connectionIdleLifetime = value;
            SetValue(nameof(ConnectionIdleLifetime), value);
        }
    }
