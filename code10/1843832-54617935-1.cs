        public class Command {
            public readonly string Name;
            static Either<Error, Func<string, EitherAsync<Error, R>>> GetCommand<R>(
                Map<string, Func<string, EitherAsync<Error, R>>> commandMap, 
                Command hostCommand) =>
                     commandMap.Find(hostCommand.Name)
                               .ToEither(new Error());
            internal static EitherAsync<Error, R> ExecuteCommand<R>(
                Func<string, EitherAsync<Error, R>> command,
                Command cmd) =>
                    command(cmd.Name);
            static Either<Error, Unit> Validate<R>(
                Map<string, Func<string, EitherAsync<Error, R>>> commandMap, 
                Command hostCommand) =>
                    commandMap.Find(hostCommand.Name)
                              .Map(_ => unit)
                              .ToEither(new Error());
            public static EitherAsync<Error, Seq<R>> ExecuteAllAsync<R>(
                Map<string, Func<string, EitherAsync<Error, R>>> commandMap,
                Seq<Command> hostCommands) =>
                    hostCommands.Map(cmd =>
                        from _ in Command.Validate(commandMap, cmd).ToAsync()
                        from f in Command.GetCommand<R>(commandMap, cmd).ToAsync()
                        from r in Command.ExecuteCommand(f, cmd)
                        select r)
                       .Sequence();
        }
