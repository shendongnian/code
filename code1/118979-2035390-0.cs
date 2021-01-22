    [CompilerGenerated, DebuggerDisplay(@"\{ Message = {Message}, MessageID = {MessageID} }", Type="<Anonymous Type>")]
    internal sealed class <>f__AnonymousType0<<Message>j__TPar, <MessageID>j__TPar> {
        // Fields
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly <Message>j__TPar <Message>i__Field;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly <MessageID>j__TPar <MessageID>i__Field;
        // Methods
        [DebuggerHidden]
        public <>f__AnonymousType0(<Message>j__TPar Message, <MessageID>j__TPar MessageID) {
            this.<Message>i__Field = Message;
            this.<MessageID>i__Field = MessageID;
        }
        [DebuggerHidden]
        public override bool Equals(object value) {
            var type = value as <>f__AnonymousType0<<Message>j__TPar, <MessageID>j__TPar>;
            return (((type != null) && EqualityComparer<<Message>j__TPar>.Default.Equals(this.<Message>i__Field, type.<Message>i__Field)) && EqualityComparer<<MessageID>j__TPar>.Default.Equals(this.<MessageID>i__Field, type.<MessageID>i__Field));
        }
        [DebuggerHidden]
        public override int GetHashCode() { 
            int num = 0x2e22c70c;
            num = (-1521134295 * num) + EqualityComparer<<Message>j__TPar>.Default.GetHashCode(this.<Message>i__Field);
            return ((-1521134295 * num) + EqualityComparer<<MessageID>j__TPar>.Default.GetHashCode(this.<MessageID>i__Field));
        }
        [DebuggerHidden]
        public override string ToString() {
            StringBuilder builder = new StringBuilder();
            builder.Append("{ Message = ");
            builder.Append(this.<Message>i__Field);
            builder.Append(", MessageID = ");
            builder.Append(this.<MessageID>i__Field);
            builder.Append(" }");
            return builder.ToString();
        }
        // Properties
        public <Message>j__TPar Message {
            get {
                return this.<Message>i__Field;
            }
        }
        public <MessageID>j__TPar MessageID {
            get {
                return this.<MessageID>i__Field;
            }
        }
    }
