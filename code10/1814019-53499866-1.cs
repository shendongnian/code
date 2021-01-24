    class IsEmptyEventListener implements IEventListener {
        private int eventCount = 0;
        public void eventOccurred(IEventData data, EventType type){
            // perhaps count only text rendering events?
            eventCount++;
        }
        public boolean isEmptyPage(){ return eventCount < 32; }
    }
