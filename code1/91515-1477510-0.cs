    public class Message {}
    public class TradeMessage extends Message {}
    
    public class MessageProcessor {
        public function process(Message msg) {
            //logic
        }
    
        public function process(TradeMessage msg) {
            //logic
        }
    }
