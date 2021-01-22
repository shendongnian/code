                // Ignore errors if unable to close the browser
            }
            SeleniumProcess.Stop();
            Assert.AreEqual("", _verificationErrors.ToString());
        }
        #endregion
