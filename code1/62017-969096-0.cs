    public class PrefixedTermsQueryParser extends QueryParser {
        // Some constructors...
        protected Query newTermQuery(Term term) {
            return new PrefixQuery(term);
        }
    }
