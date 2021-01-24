    var tenantId = userNotifications[0].Notification.TenantId;
    using (AbpSession.Use(tenantId, null))
    {
        // ...
    }
