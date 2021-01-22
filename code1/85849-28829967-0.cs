    public class TryParseLong {
    private boolean isParseable;
    private long value;
    public TryParseLong(String toParse) {
        try {
            value = Long.parseLong(toParse);
            isParseable = true;
        } catch (NumberFormatException e) {
            // Exception set to null to indicate it is deliberately
            // being ignored, since the compensating action
            // of clearing the parsable flag is being taken.
            e = null;
            isParseable = false;
        }
    }
    public boolean isParsable() {
        return isParseable;
    }
    public long getLong() {
        return value;
    }
    }
