    public static class InlineContainerExtensions {
        public static InlineContainer GetInlines(this Paragraph inlineContainer) {
            return inlineContainer.Inlines;
        }
        public static InlineContainer GetInlines(this Bold inlineContainer) {
            return inlineContainer.Inlines;
        }
    }
