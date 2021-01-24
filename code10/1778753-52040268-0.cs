                // server config "Website1"
                var config = server.GetApplicationHostConfiguration();
                // enable Windows authentication
                var windowsSection = config.GetSection("system.webServer/security/authentication/windowsAuthentication", "WebSite1");
                Assert.Equal(OverrideMode.Inherit, windowsSection.OverrideMode);
                Assert.Equal(OverrideMode.Deny, windowsSection.OverrideModeEffective);
                Assert.False(windowsSection.IsLocked);
                Assert.True(windowsSection.IsLocallyStored);
                var windowsEnabled = (bool)windowsSection["enabled"];
                Assert.True(windowsEnabled);
                windowsSection["enabled"] = false;
                Assert.Equal(false, windowsSection["enabled"]);
