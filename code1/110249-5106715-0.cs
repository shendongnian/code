    try {
      this.DisableEventFiring();
      item.SystemUpdate();  // or item.Update(); or item.UpdateOverwriteVersion();
    } finally {
      this.EnableEventFiring();
    }
