        private static void ProcessJobs() {
            while (true) {
                Job job = DequeueJob();
                if (job == null) {
                    break;
                }
                else {
                    // process job
                }
            }
            // when ProcessJobs returns, the thread ends
        }
