    using FakeItEasy;
    using Microsoft.Reactive.Testing;
    using NUnit.Framework;
    using ReactiveUI;
    using ReactiveUI.Testing;
    using System;
    using System.Reactive.Concurrency;
    ...
    public sealed class AppViewModelTest : ReactiveTest
    {
        [Test]
        public void SearchTerm_InvokesExecuteSearchAfterThrottle()
        {
            new TestScheduler().With(scheduler =>
            {
                var sut = new AppViewModel(A.Dummy<IGetPhotos>());
                scheduler.Schedule(() => sut.SearchTerm = "A");
                scheduler.Schedule(TimeSpan.FromTicks(200), () => sut.SearchTerm += "B");
                scheduler.Schedule(TimeSpan.FromTicks(300), () => sut.SearchTerm += "C");
                scheduler.Schedule(TimeSpan.FromTicks(400), () => sut.SearchTerm += "D");
                var results = scheduler.Start(
                    () => sut.ExecuteSearch.IsExecuting,
                    0, 100, TimeSpan.FromMilliseconds(800).Ticks + 402);
                results.Messages.AssertEqual(
                    OnNext(100, false),
                    OnNext(TimeSpan.FromMilliseconds(800).Ticks + 401, true)
                );
            });
        }
        [Test]
        public void SpinnerVisibility_VisibleWhenExecuteSearchIsExecuting()
        {
            new TestScheduler().With(scheduler =>
            {
                var sut = new AppViewModel(A.Dummy<IGetPhotos>());
                
                scheduler.Schedule(TimeSpan.FromTicks(300),
                    () => sut.ExecuteSearch.Execute().Subscribe());
                var results = scheduler.Start(
                    () => sut.WhenAnyValue(x => x.SpinnerVisibility));
                results.Messages.AssertEqual(
                    OnNext(200, Visibility.Collapsed),
                    OnNext(301, Visibility.Visible),
                    OnNext(303, Visibility.Collapsed));
            });
        }
    }
