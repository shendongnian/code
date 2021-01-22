public Response zzz() {
  Response result;
  try {
    ...
  } catch (MyException) {
    result.HasError = true;
    result.Error.Level = Normal;
    result.Error.Message = "It's OK.";
  } catch (Exception) {
    result.HasError = true;
    result.Error.Level = Critical;
    result.Error.Message = "!!!!";
  }
}
Then check Response.HasError
