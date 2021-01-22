            if (someCondition) {
                lockObj.EnterReadLock();
                try {
                    Foo();
                }
                finally {
                    lockObj.ExitReadLock();
                }
            } else {
                lockObj.EnterWriteLock();
                try {
                    Foo();
                } finally {
                    lockObj.ExitWriteLock();
                }
            }
