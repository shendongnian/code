        ...
        /// <remarks>
        /// ...
        /// The shared memory region that stores the registrations has the following structure:
        ///
        ///      +---- 4 Bytes ----+
        ///      |   NumListeners  |
        ///      +-----------------+
        ///      |   Listener ID   |
        ///      +-----------------+
        ///      |   Listener ID   |
        ///      +-----------------+
        ///      |       ...       |
        ///      +-----------------+
        ///
        /// ...
        /// </remarks>      
        public SharedEvent( string name, int maxListeners = 1024 )
        {
            this.Name = name;
            this.MaximumListeners = maxListeners;
            this.localWaitHandleId = -1;
            try
            {
                this.registrationLock = new Semaphore( 1, 1, RegistrationLockName() );
                this.registrations = MemoryMappedFile.CreateOrOpen(
                    RegistrationShmemName(),
                    4 + maxListeners * 4,
                    MemoryMappedFileAccess.ReadWrite,
                    MemoryMappedFileOptions.None,
                    null,
                    HandleInheritability.None
                );
                RegisterSelf();
            }
            catch
            {
                Dispose();
                throw;
            }
        }
