	"123".ParseAs<int>(10);
	"abc".ParseAs<int>(25);
	"123,78".ParseAs<double>(10);
	"abc".ParseAs<double>(107.4);
	"2014-10-28".ParseAs<DateTime>(DateTime.MinValue);
	"monday".ParseAs<DateTime>(DateTime.MinValue);
